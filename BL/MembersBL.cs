using Association_Managment.DAL;
using Association_Managment.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

using Excel = Microsoft.Office.Interop.Excel;

namespace Association_Managment.BL
{
    public partial class MembersBL
    {
        public MembersDAL _membersDAL = new MembersDAL();
        public JobMemberDAL _JobMemberDAL = new JobMemberDAL();
        public MeetingsBL _meetingsBl = new MeetingsBL();
        public List<Member> Get(MembersCriteria criteria)
        {
            criteria = (criteria == null ? new MembersCriteria() : criteria);
            var res= _membersDAL.Get(criteria);
            return res;
        }
      

        public void AddOrEditMember(Member newMember)
        {
            _membersDAL.AddOrEditMember(newMember);
        }



        //public void EditMember(MembersCriteria criteria)
        //{
        //    _membersDAL.EditMember(criteria);
        //}
        //פרישת חבר
        public void UpdateExitMember(long id, DateTime ed)
        {
            _membersDAL.Get(new MembersCriteria()).Find(x => x.codeMember == id).ExitDate = ed;
        }



        public HttpResponseMessage ExportMembers(MembersCriteria criteria)
        {
            List<Member> list = Get(criteria);
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);


            //before your loop
            var csv = new StringBuilder();

            //in your loop
            var headLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", "תעודת זהות", "שם", "תאריך יציאה", "מייל", "תאריך הצטרפות", "סוג חבר", "הרשאת חתימה");
            csv.AppendLine(headLine);
            //Suggestion made by KyleMit
            foreach (var item in list)
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", item.IdMember, item.NameMember, item.ExitDate!=null? ((DateTime)item.ExitDate).ToString("dd/M/yyyy", CultureInfo.InvariantCulture):string.Empty, item.MailMember, item.JoinDate.ToString("dd/M/yyyy", CultureInfo.InvariantCulture), item.TypeMember == true ? "חיצוני" : "פנימי", item.AllowedSignature == true ? "מורשה" : "אינו מורשה");
                csv.AppendLine(newLine);
            }

            //after your loop

            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(csv.ToString())))
            {
                xlWorkBook.SaveAs(memoryStream);
                var result = new HttpResponseMessage();
                try
                {
                    result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(memoryStream.ToArray())
                    };
                }
                catch
                {
                    result = new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
                    {
                        Content = new ByteArrayContent(memoryStream.ToArray())
                    };
                }
                result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = $"AssociationMembersReport{DateTime.Now.ToString()}.csv"
                    };
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                return result;
            }
        }

        public string JobCode(long idJob)
        {
            switch (idJob)
            {
                case (byte)Enums.Jobs.Accountant:
                    {
                        return " Accountant";
                    }

                case (byte)Enums.Jobs.AuditCommitteeMember:
                    {
                        return " AuditCommitteeMember";
                    }

                case (byte)Enums.Jobs.Manager:
                    {
                        return " Manager";
                    }

                case (byte)Enums.Jobs.Other:
                    {
                        return " Other";
                    }
            }
            return null;
        }

        public List<JobMember> Get(JobMemberCriteria criteria)
        {
            criteria = (criteria == null ? new JobMemberCriteria() : criteria);
            return _JobMemberDAL.Get(criteria);
        }



        public HttpResponseMessage ExportMember(int codeMember)//member card
        {

            List<JobMember> list = Get(new JobMemberCriteria() { CodeMember= codeMember});

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            object misValue = System.Reflection.Missing.Value;
            xlWorkBook = xlApp.Workbooks.Add(misValue);


            //before your loop
            var csv = new StringBuilder();
            //in your loop
            var headLineMain = string.Format("{0},{1}", string.Empty, "תפקידים");
            csv.AppendLine(headLineMain);

            var headLine = string.Format("{0},{1},{2},{3}", "שם תפקיד", "תאריך התחלה", "תאריך סיום", "רשומות");
            csv.AppendLine(headLine);
            //Suggestion made by KyleMit
            foreach (var item in list)
            {
                var newLine = string.Format("{0},{1},{2},{3}", JobCode(item.CodeMember), item.DateStart != null ? ((DateTime)item.DateStart).ToString("dd/M/yyyy", CultureInfo.InvariantCulture) : string.Empty, item.DateEnd != null ? ((DateTime)item.DateEnd).ToString("dd/M/yyyy", CultureInfo.InvariantCulture) : string.Empty, item.Note);
                csv.AppendLine(newLine);
            }



            List<Meeting> list2 = _meetingsBl.Get(new MeetingsCriteria() { codeMember=codeMember});

            var headLineMain2 = string.Format("{0},{1}", string.Empty, "אסיפות");
            csv.AppendLine(headLineMain2);
            //in your loop
            var headLine2 = string.Format("{0},{1},{2},{3},{4}", "סוג פגישה", "מספר חבר", "נושא הפגישה", "תאריך פגישה", "נתיב פגישה");
            csv.AppendLine(headLine2);

            foreach (var item in list2)
            {
                //var newLine = string.Format("{0},{1},{2},{3},{4}", item.ty, item.num.SubjectMeeting, item.MeetingDate, item.MeetingDirector);

                //csv.AppendLine(newLine);
            }



            using (MemoryStream memoryStream = new MemoryStream())
            {
                xlWorkBook.SaveAs(memoryStream);

                xlWorkBook.SaveAs(memoryStream);
                var result = new HttpResponseMessage();
                try
                {
                    result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(memoryStream.ToArray())
                    };
                }
                catch
                {
                    result = new HttpResponseMessage(HttpStatusCode.ExpectationFailed)
                    {
                        Content = new ByteArrayContent(memoryStream.ToArray())
                    };
                }
                result.Content.Headers.ContentDisposition =
                    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileName = "Association members report"
                    };
                result.Content.Headers.ContentType =
                    new MediaTypeHeaderValue("application/octet-stream");

                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                return result;
            }
        }


    }
}