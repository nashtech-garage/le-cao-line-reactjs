import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import QuestionApi from 'redux/api/QuestionApi';

const initialState: {
  questions: API.Question[];
  total: number;
  questionId?: string;
  loading: boolean;
  isSuccess: boolean;
} = { questions: [], total: 0, loading: false, isSuccess: false };

export const createQuestion = createAsyncThunk(
  'Questions/CreateQuestion',
  async (data: API.Question) => {
    const res = await QuestionApi.createQuestion(data);
    return res.data.object;
  }
);

export const retrieveQuestions = createAsyncThunk(
  'Questions/GetQuestions',
  async (data: {page:number, userId?: string}) => {
    const res = await QuestionApi.getQuestions(data.page, data.userId);
    return res.data.object;
  }
);

export const updateQuestion = createAsyncThunk(
  'Questions/UpdateQuestion',
  async (data: API.Question) => {
    const res = await QuestionApi.updateQuestion(data);
    return res.data;
  }
);

export const removeQuestion = createAsyncThunk('Questions/RemoveQuestion', async (id: string) => {
  await QuestionApi.removeQuestion(id);
  return { id };
});

export const detailQuestion = createAsyncThunk('Questions/GetQuestionById', async (id: string) => {
  const res = await QuestionApi.getQuestionById(id);
  return res.data.object;
});

const questionSlice = createSlice({
  name: 'question',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    // Create question
    builder.addCase(createQuestion.pending, (state, action) => {
      state.loading = true;
    });
    builder.addCase(createQuestion.fulfilled, (state, action) => {
      return { ...state, loading: false, isSuccess: false, questionId: action.payload.data };
    });
    builder.addCase(createQuestion.rejected, (state, action) => {
      state.loading = false;
      state.isSuccess = false;
    });
    // Get Questions
    builder.addCase(retrieveQuestions.pending, (state, action) => {
      state.loading = true;
    });
    builder.addCase(retrieveQuestions.rejected, (state, action) => {
      state.loading = false;
      state.isSuccess = false;
      // return { ...state, questions: [] };
    });
    builder.addCase(retrieveQuestions.fulfilled, (state, action) => {
      return {
        ...state,
        isSuccess: true,
        loading: false,
        questions: action.payload.object,
        total: action.payload.total,
      };
    });
    // Detail question
    builder.addCase(detailQuestion.pending, (state, action) => {
      state.loading = true;
    });
    builder.addCase(detailQuestion.rejected, (state, action) => {
      state.loading = false;
      state.isSuccess = false;
    });
    builder.addCase(detailQuestion.fulfilled, (state, action) => {
      // state.loading = false;
      // state.isSuccess = true;
      return action.payload;
    });
    // Update question
    builder.addCase(updateQuestion.pending, (state, action) => {
      state.loading = true;
    });
    builder.addCase(updateQuestion.fulfilled, (state, action) => {
      const index = state.questions.findIndex((question) => question.id === action.payload.id);
      state.loading = false;
      state.isSuccess = true;
      state.questions[index] = {
        ...state.questions[index],
        ...action.payload,
      };
    });
    builder.addCase(updateQuestion.rejected, (state, action) => {
      state.loading = false;
      state.isSuccess = false;
    });

    // Delete question
    builder.addCase(removeQuestion.pending, (state, action) => {
      state.loading = true;
    });
    builder.addCase(removeQuestion.fulfilled, (state, action) => {
      state.loading = false;
      state.isSuccess = true;
      let index = state.questions.findIndex(({ id }) => id === action.payload.id);
      state.questions.splice(index, 1);
    });
    builder.addCase(removeQuestion.rejected, (state, action) => {
      state.loading = false;
      state.isSuccess = false;
    });
  },
});

const { reducer } = questionSlice;
export default reducer;
