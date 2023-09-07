import { Layout, Menu } from 'antd';
import { useAppSelector } from 'app/hooks';
import { menus } from 'constants/menus';
import { UNKNOWN } from 'constants/roles';
import { useEffect, useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
const { Sider } = Layout;

export const Sidebar = (props: any) => {
  const { collapsed } = props;
  let location = useLocation();
  const isLogin = useAppSelector((state) => state.auth.isLoggedIn);
  const user = useAppSelector((state) => state.auth.user);
  const path = location.pathname.replace('/', '');
  const [current, setCurrent] = useState(path);

  const role = user ? user.roles : [''];

  useEffect(() => {
    if (location) {
      if (current !== location.pathname) {
        let path = location.pathname.replace('/', '');
        const indexOfFirst = path.indexOf('/');
        if (indexOfFirst !== -1) {
          path = path.slice(0, indexOfFirst);
        }
        setCurrent(path);
      }
    }
  }, [location, current]);
  function handleClick(e: any) {
    setCurrent(e.key);
  }

  return (
    <Sider
      className="site-layout-background"
      collapsible
      collapsed={collapsed}
      style={{
        overflow: 'auto',
        height: '100vh',
        position: 'fixed',
        left: 0,
        top: 10,
        bottom: 0,
      }}
      width={250}
      onCollapse={(value) => props.handleCollapsed(value)}
    >
      <div className="logo" style={{ textAlign: 'center', padding: '19px 0px' }}>
        <Link to="/home" style={{ color: '#fff' }}>
          EXAM
        </Link>
      </div>
      <div className="sidebar__menu">
        <Menu
          // defaultSelectedKeys={['home']}
          mode="inline"
          onClick={handleClick}
          selectedKeys={[current]}
        >
          {menus.map((item: any) => {
            return item.permission.includes(UNKNOWN) ||
              (isLogin &&
                role.filter((x: any) => item.permission.includes(x.toLowerCase())).length > 0) ? (
              item.children.length > 0 ? (
                <Menu.SubMenu title={item.label} key={item.key} icon={item.icon}>
                  {item.children.map((subItem: any) => {
                    return (
                      <Menu.Item key={subItem.key} icon={subItem.icon}>
                        <Link to={subItem.path} className="nav-text">
                          {subItem.label}
                        </Link>
                      </Menu.Item>
                    );
                  })}
                </Menu.SubMenu>
              ) : (
                <Menu.Item key={item.key} icon={item.icon}>
                  <Link to={item.path} className="nav-text">
                    {item.label}
                  </Link>
                </Menu.Item>
              )
            ) : null;
          })}
        </Menu>
      </div>
    </Sider>
  );
};
