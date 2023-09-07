import { useAppSelector } from 'app/hooks';

import Loading from 'components/Loading';
import ScrollToTop from 'components/ScrollToTop/ScrollToTop';
import { EXAM_URL } from 'configs/configs';
import { BLANK, HOME_URL, SLASH } from 'constants/constants';
import { ShowRoutes } from 'helper/Func/ShowRoutes';
import { Fragment, Suspense, useEffect } from 'react';
import { BrowserRouter as Router } from 'react-router-dom';
import routerAuth from 'routers/routerAuth';
import routerHome from 'routers/routerHome';

function App() {
  const isLogin = useAppSelector((state) => state.auth.isLoggedIn);

  useEffect(() => {
    if (window.location.pathname === SLASH || window.location.pathname === BLANK) {
      window.location.href = EXAM_URL + HOME_URL;
    }
  }, []);

  return (
    <Fragment>
      <Router>
        <ScrollToTop />
        <Suspense fallback={<Loading />}>
          {isLogin ? ShowRoutes(routerHome) : ShowRoutes(routerAuth)}
        </Suspense>
      </Router>
    </Fragment>
  );
}

export default App;
