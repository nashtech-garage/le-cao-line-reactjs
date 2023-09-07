import { useAppSelector } from 'app/hooks';
import Loading from 'components/Loading';
import { UNKNOWN } from 'constants/roles';
import { Suspense } from 'react';
import { Route, Routes } from 'react-router-dom';

export const ShowRoutes = (routers: Array<MODEL.RouteElement>) => {
  const isLogin = useAppSelector((state) => state.auth.isLoggedIn);
  const user = useAppSelector((state) => state.auth.user);
  const role = user ? user.roles : [''];

  let result: any = [];
  if (routers.length > 0) {
    result = routers.map((route: MODEL.RouteElement, index: number) => {
      return route.permission.includes(UNKNOWN) ||
        (isLogin &&
          role.filter((x: any) => route.permission.includes(x.toLowerCase())).length > 0) ? (
        <Route
          key={index}
          path={route.path}
          element={<Suspense fallback={<Loading />}>{route.main}</Suspense>}
        />
      ) : null;
    });
  }
  return <Routes>{result}</Routes>;
};
