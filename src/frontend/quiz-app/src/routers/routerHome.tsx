import { ADMIN, UNKNOWN, USER } from 'constants/roles';
import React from 'react';
// import UserPage from 'features/UserPage';
export const Logout = React.lazy(() => import('components/Logout'));
export const UserPage = React.lazy(() => import('pages/UserPage'));

const routerHome: Array<MODEL.RouteElement> = [
  {
    path: '/*',
    main: <UserPage />,
    pathComponent: 'features/UserPage',
    permission: [USER, UNKNOWN, ADMIN],
  },
  {
    path: 'logout',
    main: <Logout />,
    pathComponent: 'components/Logout',
    permission: [USER, ADMIN],
  },
];

export default routerHome;
