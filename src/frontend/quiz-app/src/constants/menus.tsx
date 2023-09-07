import React from 'react';

import {
  FileProtectOutlined,
  FileUnknownOutlined,
  HomeOutlined,
  ProfileOutlined
} from '@ant-design/icons';
import {
  AiFillCopy, AiOutlineUserSwitch,
  AiOutlineWarning
} from 'react-icons/ai';
import { ADMIN, UNKNOWN, USER } from './roles';
export const NotFound = React.lazy(() => import('components/NotFound'));
export const Logout = React.lazy(() => import('components/Logout'));
export const Home = React.lazy(() => import('pages/Home'));
export const QuestionManagement = React.lazy(() => import('pages/QuestionManagement'));
export const menus: Array<MODEL.MenuElement> = [
  {
    key: 'home',
    label: 'Home page',
    path: 'home',
    icon: <HomeOutlined />,
    children: [],
    permission: [USER, UNKNOWN, ADMIN],
  },
  {
    key: 'question-management',
    label: 'Question Management',
    path: 'question-management',
    icon: <FileUnknownOutlined />,
    children: [],
    permission: [USER, ADMIN],
  },
  {
    key: 'exams',
    label: 'Exam Management',
    path: 'exams',
    icon: <ProfileOutlined />,
    children: [],
    permission: [USER, ADMIN],
  },
  {
    key: 'users-management',
    path: 'users-management',
    label: 'User Management',
    icon: <FileProtectOutlined />,
    children: [
      {
        key: 'history-exam',
        path: 'history-exam',
        label: 'History Exam',
        icon: <AiFillCopy />,
        children: [],
        permission: [USER, ADMIN],
      },
      // {
      //   key: 'change-password',
      //   path: 'change-password',
      //   label: 'Change password',
      //   icon: <AiOutlineWarning />,
      //   children: [],
      //   permission: [USER, ADMIN],
      // },
      // {
      //   key: 'user-info',
      //   path: 'user-info',
      //   label: 'User Information',
      //   icon: <AiOutlineUserSwitch />,
      //   children: [],
      //   permission: [USER, ADMIN],
      // },
    ],
    permission: [ADMIN, USER],
  },
];
