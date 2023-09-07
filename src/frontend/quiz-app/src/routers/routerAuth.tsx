import { ADMIN, UNKNOWN, USER } from 'constants/roles';
import React from 'react';
const NotFound = React.lazy(() => import('components/NotFound'));
const Login = React.lazy(() => import('pages/Login'));
const Register = React.lazy(() => import('pages/Register'));
const UserPage = React.lazy(() => import('pages/UserPage'));

const routerAuth: Array<MODEL.RouteElement> = [
  {
    path: '/*',
    main: <UserPage />,
    pathComponent: 'pages/UserPage',
    permission: [USER, UNKNOWN, ADMIN],
  },
  {
    path: 'login',
    main: <Login />,
    pathComponent: 'pages/Login',
    permission: [USER, UNKNOWN, ADMIN],
  },
  {
    path: 'register',
    main: <Register />,
    pathComponent: 'pages/Register',
    permission: [USER, UNKNOWN, ADMIN],
  },
  {
    path: '*',
    main: <NotFound />,
    pathComponent: 'components/NotFound',
    permission: [USER, UNKNOWN, ADMIN],
  },
];

export default routerAuth;
