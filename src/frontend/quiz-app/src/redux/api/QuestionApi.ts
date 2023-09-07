import { ITEM_PER_PAGE } from 'constants/numberValue';
import { api } from 'services/api.service';

const getQuestions = (page: number, userId?: string) => {
  const query: API.PageQuery =  {
    page: page,
    pageSize: ITEM_PER_PAGE
  };

  return api.post('/Questions/GetQuestions', 
  userId ? { ...query, userId: userId } : { ...query });
};

const getQuestionById = (id: string) => {
  return api.post(`/Questions/GetQuestionById`, { userId: '', questionId: id });
};

const createQuestion = (data: API.Question) => {
  return api.post('/Questions/CreateQuestion', data);
};

const updateQuestion = (data: API.Question) => {
  return api.put(`/Questions/UpdateQuestion`, data);
};

const removeQuestion = (id: string) => {
  return api.post(`/Questions/RemoveQuestion`, { questionId: id });
};

const getQuestionTypes = () => {
  return api.get('/Questions/GetQuestionTypes');
};

const QuestionApi = {
  getQuestionById,
  createQuestion,
  updateQuestion,
  removeQuestion,
  getQuestionTypes,
  getQuestions,
};

export default QuestionApi;
