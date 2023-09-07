import { LOGOUT_URL } from './../constants/constants';
/* eslint-disable react-hooks/rules-of-hooks */
import AuthService from 'redux/api/authApi';
import { apiAuth } from './api.service';
import authHeader from './auth-header';
import TokenService from './token.service';
export const errorHandler = (error: any) => {
  return Promise.reject(error);
};

export const responseHandler = async (response: any) => {
  console.log(response);
  // Access Token was expired
  if (response.status === 401) {
    try {
      const res = await AuthService.refreshToken(TokenService.getLocalRefreshToken());
      const { accessToken } = res.data;
      TokenService.updateLocalAccessToken(accessToken);
      const win: Window = window;
      win.location = LOGOUT_URL;
    } catch (_error) {
      return Promise.reject(_error);
    }
  }
  return response;
};

export const requestHandler = async (request: any) => {
  authHeader(request);
  return request;
};

apiAuth.interceptors.request.use(
  (request) => requestHandler(request),
  (error) => errorHandler(error)
);

apiAuth.interceptors.response.use(
  (response) => responseHandler(response),
  (error) => errorHandler(error)
);

export default apiAuth;
