using Oracle.DataAccess.Client;
using Shared.Data;
using Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamkeen.IndividualsServices.Data
{
    public class OracleRepository : IOracleRepository
    {
        string _connectionString;
        string _schema;

        public OracleRepository(string connectionString, string schema)
        {
            _connectionString = connectionString;
            _schema = schema;
        }

        public IEnumerable<SponsorTransferRequest> GetSponsorTransferRequestByIdNumber(long idNumber)
        {
            var connection = new OracleConnection(_connectionString);

            OracleCommand command = new OracleCommand
            {
                CommandType = CommandType.Text,
                CommandText = $@"SELECT
                                  application.lab_off ,
                                  application.ser_yy ,
                                  application.ser_no ,
                                  application_laborer.id_no ,
                                  application.lab_off_cmpy ,
                                  application.cmpy_no , 
                                  new_establishment.CMPYNAME ,  
                                  application.olab_off_cmpy ,
                                  application.ocmpy_no , 
                                  application.OCMPYNAME ,
                                  application.trs_stus ,
                                  application.MOL_INS_TIMESTAMP
                                FROM
                                  srv_trf_appl application ,
                                  srv_trf_labors application_laborer ,
                                  wfr11 laborer ,
                                  wfr2 new_establishment
                                WHERE
                                  application_laborer.lab_off = application.lab_off
                                    AND application_laborer.ser_yy = application.ser_yy
                                    AND application_laborer.ser_no = application.ser_no
                                    AND application_laborer.id_no = laborer.id_no
                                    AND application.lab_off_cmpy = new_establishment.lab_off_cmpy
                                    AND application.cmpy_no = new_establishment.cmpy_no
                                    AND laborer.id_no= :id_number",
                Connection = connection
            };

            command.Parameters.Add("id_number", idNumber);

            IDataReader reader = null;

            var dtRequests = new DataTable();

            try
            {
                connection.Open();

                reader = command.ExecuteReader();
                dtRequests.Load(reader);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }

            var requests = new List<SponsorTransferRequest>();

            foreach (DataRow row in dtRequests.Rows)
            {
                requests.Add(FillSponsorTransferRequest(row));
            }

            return requests;
        }

        public SponsorTransferRequest GetSponsorTransferRequestByRequestNumber(int laborOfficeId, int year, long sequenceNumber)
        {
            var connection = new OracleConnection(_connectionString);

            OracleCommand command = new OracleCommand
            {
                CommandType = CommandType.Text,
                CommandText = $@"SELECT 
                                  application.lab_off ,
                                  application.ser_yy ,
                                  application.ser_no ,
                                  application_laborer.id_no ,
                                  application.lab_off_cmpy ,
                                  application.cmpy_no , 
                                  new_establishment.CMPYNAME ,  
                                  application.olab_off_cmpy ,
                                  application.ocmpy_no , 
                                  application.OCMPYNAME ,
                                  application.trs_stus ,
                                  application.MOL_INS_TIMESTAMP
                                FROM
                                  srv_trf_appl application ,
                                  srv_trf_labors application_laborer ,
                                  wfr11 laborer ,
                                  wfr2 new_establishment
                                WHERE
                                  application_laborer.lab_off = application.lab_off
                                    AND application_laborer.ser_yy = application.ser_yy
                                    AND application_laborer.ser_no = application.ser_no
                                    AND application_laborer.id_no = laborer.id_no
                                    AND application.lab_off_cmpy = new_establishment.lab_off_cmpy
                                    AND application.cmpy_no = new_establishment.cmpy_no
                                    AND application.lab_off= :labor_office_id 
                                    AND application.ser_yy= :year
                                    AND application.ser_no= :ser_no
                                    AND rownum = 1",
                Connection = connection
            };

            command.Parameters.Add("labor_office_id", laborOfficeId);
            command.Parameters.Add("year", year);
            command.Parameters.Add("ser_no", sequenceNumber);

            IDataReader reader = null;

            var dtRequests = new DataTable();

            try
            {
                connection.Open();

                reader = command.ExecuteReader();
                dtRequests.Load(reader);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                reader?.Close();
                connection?.Close();
            }

            if (dtRequests.Rows == null && dtRequests.Rows.Count == 0)
            {
                return null;
            }

            return FillSponsorTransferRequest(dtRequests.Rows[0]);
        }

        private SponsorTransferRequest FillSponsorTransferRequest(DataRow row)
        {
            return new SponsorTransferRequest
            {
                IdNumber = (long)row["ID_NO"],
                LaborOfficeId = int.Parse(row["LAB_OFF"].ToString()),
                SeqeunceNumber = long.Parse(row["SER_NO"].ToString()),
                NewEstablishmentLaborOfficeId = int.Parse(row["LAB_OFF_CMPY"].ToString()),
                NewEstablishmentName = (string)row["CMPYNAME"],
                NewEstablishmentSequenceNumber = long.Parse(row["CMPY_NO"].ToString()),
                OldEstablishmentLaborOfficeId = int.Parse(row["OLAB_OFF_CMPY"].ToString()),
                OldEstablishmentName = (string)row["OCMPYNAME"],
                OldEstablishmentSequenceNumber = long.Parse(row["OCMPY_NO"].ToString()),
                RequestDate = (DateTime)row["MOL_INS_TIMESTAMP"],
                Status = (SponsorTransferRequestStatusList)int.Parse(row["TRS_STUS"].ToString()),
                Year = int.Parse(row["SER_YY"].ToString())
            };
        }

        public string UpdateSponsorTransferRequest(SponsorTransferRequest request, long userIdNumber)
        {
            var returnValue = string.Empty;

            var connection = new OracleConnection(_connectionString);

            OracleCommand command = new OracleCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = $@"{_schema}.srv_trf_appl$web_upd_order",
                Connection = connection
            };

            command.Parameters.Add("P_LAB_OFF", request.LaborOfficeId);
            command.Parameters.Add("P_SER_YY", request.Year);
            command.Parameters.Add("P_SER_NO", request.SeqeunceNumber);
            command.Parameters.Add("P_ID_NO", request.IdNumber);
            command.Parameters.Add("P_TRS_STUS", (int)request.Status);
            command.Parameters.Add("o_lab_off_cmpy", request.OldEstablishmentLaborOfficeId);
            command.Parameters.Add("o_cmpy_no", request.OldEstablishmentSequenceNumber);
            command.Parameters.Add("p_user_IdNo", userIdNumber);
            command.Parameters.Add("RetVal", OracleDbType.Varchar2, 200, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Current, string.Empty);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                returnValue = command.Parameters["RetVal"].Value.ToString();

                if (string.IsNullOrEmpty(returnValue) || returnValue == "-1" || returnValue == "-2" || returnValue == "-3" || returnValue == "-4" || returnValue == "-5")
                {
                    throw new Exception($"Oracle transaction failed during ST Update, oracle statement return {returnValue}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection?.Close();
            }

            return returnValue.Trim();
        }
    }
}
