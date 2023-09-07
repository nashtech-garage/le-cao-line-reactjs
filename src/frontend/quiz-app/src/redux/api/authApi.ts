import { userStorage } from 'constants/storage';
import {
  AUTH_LOGIN,
  AUTH_REFRESH_TOKEN, AUTH_REGISTER
} from 'constants/urlApi';
import { ILogin, IRegister } from 'models/Auth';
import apiAuth from 'services/setupAuthInterceptors';
import TokenService from 'services/token.service';

const register = (register: IRegister) => {
  return apiAuth.post(AUTH_REGISTER, register);
};

const refreshToken = (refreshToken: string) => {
  return apiAuth.post(AUTH_REFRESH_TOKEN, refreshToken);
};

const login = (login: ILogin) => {
  return apiAuth.post(AUTH_LOGIN, login).then((response) => {
    if (response.data.object.accessToken) {
      TokenService.setUser(response.data.object);
    }
    return response.data;
  });
};
const logout = () => {
  TokenService.removeUser();
  // return apiAuth.post(AUTH_LOGOUT);
};
const getCurrentUser = () => {
  return JSON.parse(userStorage);
};
const AuthService = {
  register,
  refreshToken,
  login,
  logout,
  getCurrentUser,
};
export default AuthService;
