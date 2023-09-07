import { toast } from 'react-toastify';

export const notificationSuccess = (message: string, duration?: number) => {
  return toast.success(message, {
    position: 'top-right',
    autoClose: duration && 500,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
    theme: 'colored',
  });
};

export const notificationError = (message: string, duration?: number) => {
  return toast.error(message, {
    position: 'top-right',
    autoClose: duration && 500,
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: true,
    draggable: true,
    progress: undefined,
    theme: 'colored',
  });
};
