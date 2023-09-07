import { ITEM_PER_PAGE } from 'constants/numberValue';
import { api } from 'services/api.service';

class ExamManagementApi {
  getExams(page: number, userId?: string) {
    const query: API.PageQuery = {
      page: page,
      pageSize: ITEM_PER_PAGE,
    };
    return api.post('/Exams/GetExams', 
    userId ? { ...query, userId: userId } : { ...query });
  }

  getExamResults(page: number, userId?: string) {
    const query: API.PageQuery = {
      page: page,
      pageSize: ITEM_PER_PAGE,
    };
    return api.post('/Exams/GetExamResults', 
    userId ? { ...query, userId: userId } : { ...query });
  }

  remove(id: string) {
    return api.post(`/Exams/RemoveExam`, { examId: id });
  }

  getDetail(id: string) {
    return api.post(`/Exams/GetExamById`, { examId: id });
  }

  getResultDetail(id: string) {
    return api.post(`/Exams/GetExamResultById`, { examResultId: id });
  }

  create(data: any) {
    return api.post('/Exams/CreateExam', {
      ...data,
      requestType: 'json',
    });
  }

  update(data: any) {
    return api.put(`/Exams/UpdateExam`, {
      ...data,
      requestType: 'json',
    });
  }

  takeExam(id: string) {
    return api.post(`/Exams/TakeExam`, { examId: id });
  }

  submitExam(data: any) {
    return api.post('/Exams/SubmitExam', {
      ...data,
      requestType: 'json',
    });
  }
}
export default new ExamManagementApi();
