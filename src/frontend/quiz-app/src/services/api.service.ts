import axios from 'axios';
import { API_URL, AUTH_URL } from 'configs/configs';

export const api = axios.create({
  baseURL: API_URL,
  headers: {
    'Access-Control-Allow-Origin': '*',
    'content-type': 'application/json',
  },
});

export const apiAuth = axios.create({
  baseURL: AUTH_URL,
  headers: {
    'Access-Control-Allow-Origin': '*',
    'content-type': 'application/json',
  },
});
