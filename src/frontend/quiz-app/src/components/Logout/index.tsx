import { useAppDispatch } from 'app/hooks';
import { LOGOUT_SUCCESS } from 'constants/Messages';
import { notificationSuccess } from 'helper/Notification';
import { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { logout } from 'redux/features/authSlice';
export default function Logout() {
  const dispatch = useAppDispatch();
  const nav = useNavigate();
  useEffect(() => {
    localStorage.removeItem('token');
    dispatch(logout());
    notificationSuccess(LOGOUT_SUCCESS, 1000);
    nav('/login');
  }, [dispatch, nav]);
  return <div>Logout</div>;
}
