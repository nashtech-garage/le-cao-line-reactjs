import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import { userStorage } from 'constants/storage';
import {
  AUTH_LOGIN,
  AUTH_LOGOUT,
  AUTH_REFRESH_TOKEN, AUTH_REGISTER
} from 'constants/urlApi';
import { ILogin, IRegister } from 'models/Auth';
import AuthService from 'redux/api/authApi';
const user = JSON.parse(userStorage) || null;

export const register = createAsyncThunk(AUTH_REGISTER, async (register: IRegister, thunkAPI) => {
  try {
    const response = await AuthService.register(register);
    return response.data;
  } catch (error: any) {
    return thunkAPI.rejectWithValue(error.response.data);
  }
});
export const login = createAsyncThunk(AUTH_LOGIN, async (login: ILogin, thunkAPI) => {
  try {
    const response = await AuthService.login(login);
    return { user: response.object };
  } catch (error: any) {
    const message =
      (error.response && error.response.data && error.response.data.message) ||
      error.message ||
      error.toString();
    return thunkAPI.rejectWithValue(message);
  }
});
export const logout = createAsyncThunk(AUTH_LOGOUT, async () => {
  await AuthService.logout();
});

export const refreshToken = createAsyncThunk(
  AUTH_REFRESH_TOKEN,
  async (accessToken: string, thunkAPI) => {
    try {
      // const { accessToken } = user;
      const data = await AuthService.refreshToken(accessToken);
      return { refreshToken: data.data.refreshToken };
    } catch (error: any) {
      const message =
        (error.response && error.response.data && error.response.data.message) ||
        error.message ||
        error.toString();
      return thunkAPI.rejectWithValue(message);
    }
  }
);
interface AuthState {
  isLoggedIn: boolean;
  user: any;
}

const initialState: AuthState = user
  ? { isLoggedIn: true, user: user }
  : { isLoggedIn: false, user: null };

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    // When a server responses with the data,
    builder.addCase(register.fulfilled, (state, { payload }) => {
      state.isLoggedIn = false;
    });
    // When a server responses with an error:
    builder.addCase(register.rejected, (state, action) => {
      state.isLoggedIn = false;
    });
    // When a server responses with the data,
    builder.addCase(login.fulfilled, (state, action) => {
      state.isLoggedIn = true;
      const { user }: any = action.payload;
      state.user = user;
    });
    // When a server responses with an error:
    builder.addCase(login.rejected, (state, action) => {
      state.isLoggedIn = false;
      state.user = null;
    });
    // When a server responses with the data,
    builder.addCase(logout.fulfilled, (state, action) => {
      state.isLoggedIn = false;
      state.user = null;
    });
    // When a server responses with the data,
    builder.addCase(refreshToken.fulfilled, (state, action) => {
      state.isLoggedIn = true;
      const { refreshToken }: any = action.payload;
      state.user.refreshToken = refreshToken;
    });
  },
});
const { reducer } = authSlice;
export default reducer;
