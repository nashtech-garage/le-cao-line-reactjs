import { userStorage } from 'constants/storage';

export default function authHeader(request: any) {
  const user = JSON.parse(userStorage);
  if (user && user.accessToken) {
    return request.headers.Authorization = `Bearer ${user.accessToken}`;
  }
}
