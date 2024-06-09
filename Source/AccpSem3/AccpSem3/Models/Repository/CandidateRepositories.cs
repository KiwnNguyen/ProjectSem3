using AccpSem3.Models.Entities;
using AccpSem3.Models.ModeView;
using AccpSem3.Models.ModeView.ModelJoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccpSem3.Models.Repository
{
    public class CandidateRepositories
    {
        private static CandidateRepositories instance;
        private CandidateRepositories() { }
        public static CandidateRepositories Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateRepositories();
                }
                return instance;
            }
        }

        public void UpdateCadi(int id, int score1, string listAnswer, string listAnswer_of_cadidate)
        {
            try
            {
                if (id != 0)
                {
                    if (score1 != 0 && listAnswer != null)
                    {

                        using (dbSem3Entities entities = new dbSem3Entities())
                        {
                            var cadidate = entities.Cadidates.Find(id);
                            if (cadidate != null)
                            {
                                cadidate.score = score1;
                                cadidate.answer_of_cadidate = listAnswer;
                                cadidate.status = 0;
                                cadidate.submit_cadidate_cadidate = listAnswer_of_cadidate;
                                entities.SaveChanges();
                            }
                        }

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void SubmitSendInfo(CadidateView model)
        {
            try
            {
                if (model != null)
                {
                    Cadidate cadi = new Cadidate();
                    dbSem3Entities entities = new dbSem3Entities();
                    cadi.id_member = model.id_member;
                    cadi.id_vacancy = model.id_vacancy;
                    cadi.created_at = DateTime.Now;
                    cadi.updated_at = DateTime.Now;
                    cadi.status = 4;
                    cadi.concern_person = model.concern_person;
                    entities.Cadidates.Add(cadi);
                    entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<CadidateView> GetByIdCadi(int id)
        {
            try
            {
                dbSem3Entities entities = new dbSem3Entities();
                var q = entities.Cadidates.Where(y => y.id == id).ToList();
                var caidateViews = q.Select(Cadidate => new CadidateView
                {
                    id = Cadidate.id,
                    id_member = Cadidate.id_member,
                    id_vacancy = Cadidate.id_vacancy,
                    concern_person = Cadidate.concern_person,
                    status = Cadidate.status,
                    username = Cadidate.username,
                    password = Cadidate.password,
                    score = Cadidate.score,
                    answer_of_cadidate = Cadidate.answer_of_cadidate,
                    created_at = Cadidate.created_at,
                    updated_at = Cadidate.updated_at,
                    submit_cadidate_cadidate = Cadidate.submit_cadidate_cadidate

                }).ToList();
                return caidateViews;
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public List<CadidateView> GetById(string username1)
        {
            try
            {

                dbSem3Entities entities = new dbSem3Entities();
                var q = entities.Cadidates.Where(y => y.username == username1).ToList();

                var caidateViews = q.Select(Cadidate => new CadidateView
                {
                    id = Cadidate.id,
                    id_member = Cadidate.id_member,
                    id_vacancy = Cadidate.id_vacancy,
                    concern_person = Cadidate.concern_person,
                    status = Cadidate.status,
                    username = Cadidate.username,
                    password = Cadidate.password,
                    score = Cadidate.score,
                    answer_of_cadidate = Cadidate.answer_of_cadidate,
                    created_at = Cadidate.created_at,
                    updated_at = Cadidate.updated_at,
                    submit_cadidate_cadidate = Cadidate.submit_cadidate_cadidate

                }).ToList();
                return caidateViews;
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public IEnumerable<ScoreResultCadi> GetQuantiyCandil(int? id_van)
        {
            try
            {
                if (id_van != null)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q1 = from a in entities.Vacancies
                             join b in entities.Cadidates on a.id equals b.id_vacancy
                             join c in entities.Members on b.id_member equals c.id
                             where b.id_vacancy == id_van
                             select new ScoreResultCadi
                             {
                                 vacancy = a,
                                 cadidate = b,
                                 member = c,

                             };
                    return q1.ToList();
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public IEnumerable<CadidateView> GetByNameStatus(string username1)
        {
            try
            {

                dbSem3Entities entities = new dbSem3Entities();
                var q = entities.Cadidates.Where(y => y.username == username1).ToList();

                var caidateViews = q.Select(Cadidate => new CadidateView
                {
                    id = Cadidate.id,
                    id_member = Cadidate.id_member,
                    id_vacancy = Cadidate.id_vacancy,
                    concern_person = Cadidate.concern_person,
                    status = Cadidate.status,
                    username = Cadidate.username,
                    password = Cadidate.password,
                    score = Cadidate.score,
                    answer_of_cadidate = Cadidate.answer_of_cadidate,
                    created_at = Cadidate.created_at,
                    updated_at = Cadidate.updated_at,

                }).ToList();
                return caidateViews;
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public List<CadidateView> GetByIdMem(int? id_mem)
        {
            try
            {

                dbSem3Entities entities = new dbSem3Entities();
                var q = entities.Cadidates.Where(y => y.id_member == id_mem).ToList();

                var caidateViews = q.Select(Cadidate => new CadidateView
                {
                    id = Cadidate.id,
                    id_member = Cadidate.id_member,
                    id_vacancy = Cadidate.id_vacancy,
                    concern_person = Cadidate.concern_person,
                    status = Cadidate.status,
                    username = Cadidate.username,
                    password = Cadidate.password,
                    score = Cadidate.score,
                    answer_of_cadidate = Cadidate.answer_of_cadidate,
                    created_at = Cadidate.created_at,
                    updated_at = Cadidate.updated_at,
                    submit_cadidate_cadidate = Cadidate.submit_cadidate_cadidate

                }).ToList();
                return caidateViews;
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
        public int CreateAccountCadi(CadidateView model)
        {
            try
            {
                if (model != null)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(model.id);
                    if (q != null)
                    {
                        q.username = model.username;
                        q.password = model.password;
                        q.status = 3;
                        q.expire_date = model.expire_date;
                        entities.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int UpdateDateCadidate()
        {
            try
            {
                using (var entities = new dbSem3Entities())
                {
                    var allCadidates = entities.Cadidates.ToList();
                    foreach (var cadidate in allCadidates)
                    {
                        cadidate.updated_at = DateTime.Now;
                    }
                    entities.SaveChanges();
                    return 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int RefusedCadi(int id)
        {
            try
            {
                if (id != null)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(id);
                    if (q != null)
                    {
                        q.status = 2;
                        entities.SaveChanges();
                    }
                    return 1;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int StatusCadiOne(int id)
        {
            try
            {
                if (id != 0)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(id);
                    if (q != null)
                    {
                        q.status = 1;
                        entities.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }

        //Get cadidate pass exam 

        public ICollection<CadidatePassExam> GetCadidatesPassExam()
        {
            try
            {
                dbSem3Entities en = new dbSem3Entities();
                var rs = en.Cadidates.Where(ca => ca.status > 4 || ca.status == 0).ToList();
                List<CadidatePassExam> cpe = new List<CadidatePassExam>();
                foreach (var item in rs)
                {
                    var rsmb = en.Members.Where(mem => mem.id == item.id_member).FirstOrDefault();
                    var rsva = en.Vacancies.Where(va => va.id == item.id_vacancy).FirstOrDefault();
                    CadidatePassExam cadidatePassExam = new CadidatePassExam();
                    cadidatePassExam.id = item.id;
                    cadidatePassExam.id_member = item.id_member;
                    cadidatePassExam.fullname = rsmb.fullname;
                    cadidatePassExam.email = rsmb.email;
                    cadidatePassExam.id_vacancy = item.id_vacancy;
                    cadidatePassExam.title_vacancy = rsva.name;
                    cadidatePassExam.concern_person = item.concern_person;
                    cadidatePassExam.status = item.status;
                    cadidatePassExam.score = item.score;
                    cadidatePassExam.answer_of_cadidate = item.answer_of_cadidate;
                    cadidatePassExam.submit_cadidate_cadidate = item.submit_cadidate_cadidate;
                    cadidatePassExam.created_at = item.created_at;
                    cadidatePassExam.updated_at = item.updated_at;
                    cadidatePassExam.expire_date = item.expire_date;
                    cpe.Add(cadidatePassExam);
                }
                return cpe;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SetInterview(int idcadi)
        {
            try
            {
                dbSem3Entities en = new dbSem3Entities();
                var rs = en.Cadidates.Where(cadi => cadi.id == idcadi).FirstOrDefault();
                if (rs != null && rs.status == 0)
                {
                    rs.status = 5;
                    en.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Member GetMemberByIdCadidate(int idcadidate)
        {
            try
            {
                dbSem3Entities en = new dbSem3Entities();
                var cadi = en.Cadidates.Where(ca => ca.id == idcadidate).FirstOrDefault();
                var rs = en.Members.Where(me => me.id == cadi.id_member).FirstOrDefault();
                return rs;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Candide_scheduleAccept(int id)
        {
            try
            {
                if (id > 0)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(id);
                    if (q != null)
                    {
                        q.status = 5;
                        entities.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int Cadide_ScheduleRefund(int id)
        {
            try
            {
                if (id > 0)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(id);
                    if (q != null)
                    {
                        q.status = 6;
                        entities.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int Cadide_AcceptJoin(int id)
        {
            try
            {
                if (id > 0)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(id);
                    if (q != null)
                    {
                        q.status = 7;
                        entities.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int Cadide_RefundJoin(int id)
        {
            try
            {
                if (id > 0)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(id);
                    if (q != null)
                    {
                        q.status = 8;
                        entities.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
        public int Cadide_View9(int id)
        {
            try
            {
                if (id > 0)
                {
                    dbSem3Entities entities = new dbSem3Entities();
                    var q = entities.Cadidates.Find(id);
                    if (q != null)
                    {
                        q.status = 9;
                        entities.SaveChanges();
                        return 1;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return 0;
        }
    }
}