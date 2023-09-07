import { Person } from "models/types";

export interface IRegister extends Person{
  VerifyPassword: string;
}

export interface ILogin extends Person{
}

export interface IUser extends Person {
  roles: string[];
}