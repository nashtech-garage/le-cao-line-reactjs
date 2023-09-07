import { Button, Form, Input } from 'antd';
import { useAppDispatch } from 'app/hooks';
import { HOME_URL, LOGIN_URL } from 'constants/constants';
import {
  INPUT_CONFIRM_PASSWORD,
  INPUT_EMAIL,
  INPUT_FIRST_NAME,
  INPUT_LAST_NAME,
  INPUT_PASSWORD,
  INPUT_PHONE,
  INPUT_USERNAME,
  NOT_MATCH_CONFIRM_PASSWORD,
  REGISTER_FAIL,
  REGISTER_SUCCESS,
  VALID_EMAIL,
} from 'constants/Messages';
import { EXISTING_USER, VALIDATOR } from 'constants/statusCode';
import { notificationError, notificationSuccess } from 'helper/Notification';
import { IRegister } from 'models/Auth';
import { Link, useNavigate } from 'react-router-dom';
import { register } from 'redux/features/authSlice';

export default function Register() {
  const nav = useNavigate();
  const dispatch = useAppDispatch();

  const onFinish = async (values: IRegister) => {
    dispatch(register(values))
      .unwrap()
      .then(() => {
        notificationSuccess(REGISTER_SUCCESS);
        nav(LOGIN_URL);
      })
      .catch((res) => {
        if (res.message === VALIDATOR) {
          var errorString = res.object
            .map(function (err: any) {
              return err.fieldName;
            })
            .join(', ');
          notificationError(`${errorString} is not valid`);
        } else if (res.message === EXISTING_USER) {
          notificationError(`${res.object.data}`);
        } else notificationError(REGISTER_FAIL);
      });
  };

  const onFinishFailed = (errorInfo: any) => {
    notificationError(errorInfo);
  };
  return (
    <div className="login-page register-page">
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
            Register to the{' '}
            <Link to={HOME_URL}>
              <strong>Driving</strong>{' '}
            </Link>{' '}
          </p>

          <Form.Item
            name="Email"
            rules={[
              {
                type: 'email',
                message: VALID_EMAIL,
              },
              {
                required: true,
                message: INPUT_EMAIL,
              },
            ]}
          >
            <Input placeholder="E-mail" />
          </Form.Item>
          <Form.Item
            name="FirstName"
            tooltip={INPUT_FIRST_NAME}
            rules={[{ required: true, message: INPUT_FIRST_NAME, whitespace: true }]}
          >
            <Input placeholder="First Name" />
          </Form.Item>
          <Form.Item
            name="LastName"
            tooltip={INPUT_LAST_NAME}
            rules={[{ required: true, message: INPUT_LAST_NAME, whitespace: true }]}
          >
            <Input placeholder="Last Name" />
          </Form.Item>
          <Form.Item name="Phone" rules={[{ required: true, message: INPUT_PHONE }]}>
            <Input style={{ width: '100%' }} placeholder="Phone Number" />
          </Form.Item>
          <Form.Item name="Username" rules={[{ required: true, message: INPUT_USERNAME }]}>
            <Input placeholder="Username" />
          </Form.Item>
          <Form.Item
            name="Password"
            rules={[
              {
                required: true,
                message: INPUT_PASSWORD,
              },
            ]}
            hasFeedback
          >
            <Input.Password placeholder="Password" />
          </Form.Item>

          <Form.Item
            name="VerifyPassword"
            dependencies={['password']}
            hasFeedback
            rules={[
              {
                required: true,
                message: INPUT_CONFIRM_PASSWORD,
              },
              ({ getFieldValue }) => ({
                validator(_, value) {
                  if (!value || getFieldValue('Password') === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject(new Error(NOT_MATCH_CONFIRM_PASSWORD));
                },
              }),
            ]}
          >
            <Input.Password placeholder="Confirm Password" />
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit" className="login-form-button">
              REGISTER
            </Button>
            <div style={{ marginTop: 15 }}>
              Do you already have an account?
              <Link style={{ color: 'red' }} to="/login">
                {' '}
                Log in!
              </Link>
            </div>
          </Form.Item>
        </Form>
      </div>
    </div>
  );
}
