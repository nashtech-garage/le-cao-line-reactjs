import { USER } from 'constants/roles';
import { userStorage } from 'constants/storage';

const getLocalRefreshToken = () => {
  const user = JSON.parse(userStorage);
  return user?.refreshToken;
};
const getLocalAccessToken = () => {
  const user = JSON.parse(userStorage);
  return user?.accessToken;
};
const updateLocalAccessToken = (token: string) => {
  let user = JSON.parse(userStorage);
  user.accessToken = token;
  localStorage.setItem(USER, JSON.stringify(user));
};
const getUser = () => {
  return JSON.parse(userStorage);
};
const setUser = (user: object) => {
  localStorage.setItem(USER, JSON.stringify(user));
};
const removeUser = () => {
  localStorage.removeItem(USER);
};
const TokenService = {
  getLocalRefreshToken,
  getLocalAccessToken,
  updateLocalAccessToken,
  getUser,
  setUser,
  removeUser,
};
export default TokenService;
