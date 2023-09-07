import { Button, Checkbox, Form, Input } from 'antd';
import { useAppDispatch } from 'app/hooks';
import { HOME_URL } from 'constants/constants';
import { LOGIN_FAIL, LOGIN_SUCCESS, MESSAGE_FAILURE } from 'constants/Messages';
import { BAD_REQUEST } from 'constants/statusCode';
import { notificationError, notificationSuccess } from 'helper/Notification';
import { ILogin } from 'models/Auth';
import { Link, useNavigate } from 'react-router-dom';
import { login } from 'redux/features/authSlice';

export default function Login() {
  const nav = useNavigate();
  const dispatch = useAppDispatch();

  const onFinish = async (values: ILogin) => {
    dispatch(login(values))
      .unwrap()
      .then(() => {
        notificationSuccess(LOGIN_SUCCESS, 1000);
        nav(HOME_URL);
      })
      .catch((res) => {
        if (res === BAD_REQUEST) {
          notificationError(LOGIN_FAIL, 1000);
        }
      });
  };
  const onFinishFailed = (errorInfo: any) => {
    notificationError(MESSAGE_FAILURE);
  };

  return (
    <div className="login-page">
      <div className="login-box">
        <div className="illustration-wrapper">
          <img
            src="https://mixkit.imgix.net/art/preview/mixkit-left-handed-man-sitting-at-a-table-writing-in-a-notebook-27-original-large.png?q=80&auto=format%2Ccompress&h=700"
            alt="Login"
          />
        </div>
        <Form
          name="login-form"
          initialValues={{ remember: true }}
          onFinish={onFinish}
          onFinishFailed={onFinishFailed}
        >
          <p className="form-title">Welcome back</p>
          <p>
            Login to the{' '}
            <Link to="/home">
              <strong>Driving</strong>
            </Link>{' '}
          </p>
          <Form.Item
            name="username"
            rules={[{ required: true, message: 'Please input your username!' }]}
          >
            <Input placeholder="Username" />
          </Form.Item>

          <Form.Item
            name="password"
            rules={[{ required: true, message: 'Please input your password!' }]}
          >
            <Input.Password placeholder="Password" />
          </Form.Item>
          <Form.Item>
            <Link className="login-form-forgot" style={{ color: 'blue' }} to="">
              Forgot password?
            </Link>
          </Form.Item>
          <Form.Item>
            <Button type="primary" htmlType="submit" className="login-form-button">
              LOGIN
            </Button>
            <div style={{ marginTop: 15 }}>
              Do not have an account?{' '}
              <Link style={{ color: 'red' }} to="/register">
                {' '}
                Register now!
              </Link>
            </div>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
}
