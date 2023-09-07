import { USER } from "./roles";

export const userStorage = localStorage.getItem(USER) || 'null';
