import { useState } from 'react';

import { Anchor, Avatar, Button, Divider, Drawer, Dropdown, Menu, Space, Tag } from 'antd';
import { AiOutlineMenu } from 'react-icons/ai';
import { useNavigate, NavLink } from 'react-router-dom';
import { useAppSelector } from 'app/hooks';
import { DownOutlined, UserOutlined } from '@ant-design/icons';
import { ADMIN, USER } from 'constants/roles';

const menuInfoUser = (
  <Menu
    items={[
      {
        label: <NavLink to="/user-info">Information</NavLink>,
        key: '0',
      },
      {
        type: 'divider',
      },
      {
        label: <NavLink to="/change-password">Change Password</NavLink>,
        key: '1',
      },
      {
        type: 'divider',
      },
      {
        label: <NavLink to="/logout">Logout</NavLink>,
        key: '3',
      },
    ]}
  />
);

const { Link } = Anchor;
function AppHeader() {
  const user = useAppSelector((state) => state.auth.user);
  const [visible, setVisible] = useState(false);

  const showDrawer = () => {
    setVisible(true);
  };

  const onClose = () => {
    setVisible(false);
  };
  const nav = useNavigate();

  const handleUrl = (event: any) => {
    if (event.target.tagName.toLowerCase() === 'a') {
      // eslint-disable-next-line @typescript-eslint/no-unused-expressions
      const href = event.target.href; //this is the url where the anchor tag points to.
      if (!href.includes('/home#')) {
        nav('/home');
      }
    }
  };
  return (
    <div className="">
      <div className="header">
        <div className="logo">
          <i className="fas fa-bolt"></i>
          <NavLink to="/home">DRIVING EXAM</NavLink>
        </div>
        <div className="mobileHidden">
          <Anchor targetOffset={65} onClick={(e) => handleUrl(e)}>
            <Link href="#hero" title="Home" />
            <Link href="#about" title="About" />
            <Link href="#feature" title="Features" />
            <Link href="#faq" title="FAQ" />
            <Link href="#contact" title="Contact" />
          </Anchor>
        </div>
        <div className="mobileVisible">
          <Button type="primary" onClick={showDrawer} style={{ right: '-80px' }}>
            <AiOutlineMenu />
          </Button>
          <Drawer placement="right" closable={false} onClose={onClose} visible={visible}>
            <Anchor targetOffset={65}>
              <Link href="#hero" title="Home" />
              <Link href="#about" title="About" />
              <Link href="#feature" title="Features" />
              <Link href="#faq" title="FAQ" />
              <Link href="#contact" title="Contact" />
              <Divider />
              <Link href="login" title="Login" />
              <Link href="register" title="Register" />
            </Anchor>
          </Drawer>
        </div>
        <div className="header__info">
          {user ? (
            <>
              <Avatar
                style={{ backgroundColor: '#2db7f5', marginRight: '0.5rem' }}
                src="https://zos.alipayobjects.com/rmsportal/ODTLcjxAfvqbxHnVXCYX.png"
              />
              <Dropdown overlay={menuInfoUser} trigger={['click']}>
                <span onClick={(e) => e.preventDefault()} className="header__info__name">
                  <Space>
                    {`${user.firstName}`}
                    <Tag color={user.roles.find((e: any) => e === ADMIN) ? '#f50' : '#2db7f5'}>
                      {user.roles.find((e: any) => e === ADMIN) ? ADMIN : USER}
                    </Tag>
                    <DownOutlined />
                  </Space>
                </span>
              </Dropdown>
            </>
          ) : (
            <div className="mobileHidden">
              <NavLink to="/login">Login</NavLink> / <NavLink to="/register">Register</NavLink>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default AppHeader;
