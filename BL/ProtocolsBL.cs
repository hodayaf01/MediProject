using Association_Managment.DAL;
using Association_Managment.Models;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using iTextSharp;
using iTextSharp.text;

namespace Association_Managment.BL
{
    public class ProtocolsBL
    {
        public ProtocolsDAL _protocolsDAL = new ProtocolsDAL();
        public AssociationDetailsDAL _associationDetailsDAL = new AssociationDetailsDAL();
        public MembersBL _membersBL = new MembersBL();

        public List<Protocol> Get()
        {
            return _protocolsDAL.Get();
        }

        public string Create(GeneralProtocol generalProtocol)
        {
            foreach (var task in generalProtocol.Tasks)
            {
                switch (task)
                {
                    case (byte)Models.Enums.Task.AddMember:
                        {
                            //add member
                            generalProtocol.NewMember.ForEach(m =>
                            {
                                _membersBL.AddOrEditMember(new Member()
                                {
                                    AllowedSignature = m.AllowedSignature,

                                });
                            });

                            break;
                        }
                    case (byte)Models.Enums.Task.QuitMember:
                        {
                            //Quit Member פרישת חבר
                            _membersBL.UpdateExitMember(generalProtocol.QuitMember.MemberCode, generalProtocol.QuitMember.Date);
                        }
                      
                        break;
                    case (byte)Models.Enums.Task.ChoosingAuditCommittee:
                        //Choosing Audit Committee~בחירת ועד ביקורת
                        break;
                    case (byte)Models.Enums.Task.AppointmentOfAccountant:
                        //Appointment Of Accountant~ מינוי רואה חשבון 
                        break;
                    case (byte)Models.Enums.Task.ConfirmReports:
                        //Confirm Reports~ אישור דוחות
                        break;
                    case (byte)Models.Enums.Task.UpdateAssociationDetail:
                        //UpdateAssociationDetail~עידכון פרטי עמותה 
                        break;
                }
            }

            return "";

        }
        //הוספת אסיפה 

        public void PDFFile(GeneralProtocol generalProtocol)
        {
            DetailsAssocition details = _associationDetailsDAL.Get();
            PdfDocument pdf = new PdfDocument();
            FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("pdf") + "\\" + $".pdf", FileMode.Create);
            // System.IO.FileStream fs = new FileStream(Server.MapPath("pdf") + "\\" + "First PDF document.pdf", FileMode.Create)
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.AddAuthor("Shai&Chedva");
            document.AddCreator("******");
            document.AddKeywords("Asscition");
            document.AddSubject("protocol");
            document.AddTitle(details.NameOfAsscition);


            // Open the document to enable you to write to the document  
            document.Open();
            // Add a simple and wellknown phrase to the document in a flow layout manner  
            document.Add(new Paragraph("בס\"ד\t\t" + "\n\n\t\t" + details.NameOfAsscition + "\n\t\t" + "מס' עמותה " + details.id + "\n\t\t_________________________"));
            document.Add(new Paragraph("\n\n\n\n\t\t פרוטוקול\n\t\t----------------------"));
            document.Add(new Paragraph(2, ""));

            //פיסקה ראשונה
            document.Add(new Paragraph("מאסיפת החברים של עמותת \"" + details.NameOfAsscition + "\""));
            //לא לשכוח תאריך עברי ויושב ראש
            document.Add(new Paragraph("שנתכנסה בתאריך " + DateTime.Today));

            //פיסקת נוכחים 
            string presents = "נוכחים: ";
            foreach (var item in _membersBL.Get(generalProtocol.Presents))
            {
                presents = string.Format("{0} ,{1}", presents, item.NameMember);
            }
            document.Add(new Paragraph(presents));

            //_____________________________
            foreach (var task in generalProtocol.Tasks)
            {
                switch (task)
                {
                    case (byte)Models.Enums.Task.AddMember:
                        //Add Member
                        string addMembers = "";
                        generalProtocol.NewMember.ForEach( m=> addMembers+=( m.NameMember+ ", מס' ת.ז" + m.NameMember + "יצורף כחבר ועדה.\n"));
                        document.Add(new Paragraph(addMembers));
                        break;
                    case (byte)Models.Enums.Task.QuitMember:
                        //Quit Member פרישת חבר
                        var m1 = _membersBL.Get(new List<long>() { generalProtocol.QuitMember.MemberCode }).First();
                        document.Add(new Paragraph("הנהלת העמותה אישרה את בקשתו" + m1.NameMember + "לפרוש מחברותו בוועדת הביקורת של העמותה החל משנת " + generalProtocol.QuitMember.Date.Year));
                        break;
                    case (byte)Models.Enums.Task.ChoosingAuditCommittee:
                        //Choosing Audit Committee בחירת ועד ביקורת
                        string auditCommitteeMembers = "";
                        foreach (var item in _membersBL.Get(generalProtocol.AuditCommitteeMembers.MemberCode))
                        {
                            auditCommitteeMembers = string.Format("{0} ,{1}", auditCommitteeMembers, item.NameMember);
                        }
                        document.Add(new Paragraph("לחברי ועדת הביקורת של העמותה לשנת" + DateTime.Today.Year + "ימונו:\n" + auditCommitteeMembers));
                        break;
                    case (byte)Models.Enums.Task.AppointmentOfAccountant:
                        //Appointment Of Accountant~ מינוי רואה חשבון 
                        var m2 = _membersBL.Get(new List<long>() { generalProtocol.Accountant.CodeMember }).First();
                        document.Add(new Paragraph("הנהלת העמותה מינתה את: " + m2.NameMember + " לרואה חשבון."));
                        break;
                    case (byte)Models.Enums.Task.ConfirmReports:
                        //Confirm Reports~ אישור דוחות
                        string confirmReports = "אישור דוחות:";
                        generalProtocol.confirmReports.Reports.ForEach(r => confirmReports += (r+"\n"));
                        document.Add(new Paragraph(confirmReports));
                        break;
                    case (byte)Models.Enums.Task.UpdateAssociationDetail:
                        //UpdateAssociationDetail~עידכון פרטי עמותה 
                        document.Add(new Paragraph("עדכון פרטי עמותה: \n "+generalProtocol.updateAssociationDetail.ToString()));
                        break;
                    case (byte)Models.Enums.Task.Other:
                        //Confirm Reports~ אישור דוחות
                        string other = "אחר:";
                        generalProtocol.Other.OtherTasks.ForEach(o => other += (o + "\n"));
                        document.Add(new Paragraph(other));
                        break;
                }
            }

            // Close the document  
            document.Close();
            // Close the writer instance  
            writer.Close();
            // Always close open filehandles explicity  
            fs.Close();
        }
    }
}