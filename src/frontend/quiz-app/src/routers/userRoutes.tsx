import { ADMIN, UNKNOWN, USER } from 'constants/roles';
import React from 'react';
export const AboutUs = React.lazy(() => import('pages/AboutUs'));
export const ExamList = React.lazy(() => import('pages/ExamManagement/ExamsList'));
export const DoExam = React.lazy(() => import('pages/ExamManagement/ExamsExam'));
export const UserResult = React.lazy(() => import('pages/ExamManagement/ExamsResult'));
export const HistoryExam = React.lazy(() => import('pages/UserManagement/HistoryExam'));
export const ExamCreationPage = React.lazy(() => import('pages/ExamManagement/ExamsCreate'));
export const ExamUpdationPage = React.lazy(() => import('pages/ExamManagement/ExamsEdit'));
export const Contact = React.lazy(() => import('pages/Contact'));
export const UserInfo = React.lazy(() => import('pages/UserManagement/UserInfo'));
export const ChangePassword = React.lazy(() => import('pages/UserManagement/ChangePassword'));

export const NotFound = React.lazy(() => import('components/NotFound'));
export const Home = React.lazy(() => import('pages/Home'));
export const QuestionManagement = React.lazy(() => import('pages/QuestionManagement'));
export const QuestionCreationPage = React.lazy(
  () => import('pages/QuestionManagement/QuestionsCreate')
);
export const QuestionUpdationPage = React.lazy(
  () => import('pages/QuestionManagement/QuestionsEdit')
);
export const DrivingLaw = React.lazy(() => import('pages/DrivingLaw'));
export const DrivingLawDetail = React.lazy(() => import('pages/DrivingLawDetail'));

export const userRoutes: Array<MODEL.RouteElement> = [
  {
    path: 'home',
    main: <Home />,
    pathComponent: 'features/Home',
    permission: [USER, ADMIN, UNKNOWN],
  },
  {
    path: 'question-management',
    main: <QuestionManagement />,
    pathComponent: 'features/QuestionManagement',
    permission: [USER, ADMIN],
  },
  {
    path: 'question-management/edit-question/:id/*',
    main: <QuestionUpdationPage />,
    permission: [USER, ADMIN],
  },
  {
    path: 'question-management/add-question/*',
    main: <QuestionCreationPage />,
    permission: [USER, ADMIN],
  },
  {
    path: 'exams',
    main: <ExamList />,
    permission: [USER, UNKNOWN],
  },
  {
    path: 'exams/create',
    main: <ExamCreationPage />,
    permission: [USER, ADMIN],
  },
  {
    path: 'exams/:id/edit',
    main: <ExamUpdationPage />,
    permission: [USER, ADMIN],
  },
  {
    path: 'exams/:id/exam',
    main: <DoExam />,
    permission: [USER, UNKNOWN],
  },
  {
    path: 'exams/:id/result',
    main: <UserResult />,
    permission: [USER, ADMIN],
  },
  {
    path: 'driving-law/:drivingLawId/*',
    main: <DrivingLawDetail />,
    pathComponent: 'features/DrivingLawDetail',
    permission: [USER, ADMIN, UNKNOWN],
  },
  {
    path: 'change-password',
    main: <ChangePassword />,
    pathComponent: 'features/ChangePassword',
    permission: [USER, ADMIN],
  },
  {
    path: 'user-info',
    main: <UserInfo />,
    pathComponent: 'features/UserInfo',
    permission: [USER, ADMIN],
  },
  {
    path: 'history-exam',
    main: <HistoryExam />,
    pathComponent: 'features/HistoryExam',
    permission: [USER, ADMIN],
  },
  {
    path: '*',
    main: <NotFound />,
    pathComponent: 'components/NotFound',
    permission: [USER, ADMIN, UNKNOWN],
  },
];

export default userRoutes;
