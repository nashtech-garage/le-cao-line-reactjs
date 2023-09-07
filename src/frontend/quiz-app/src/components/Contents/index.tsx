import { BackTop, Breadcrumb, Layout } from 'antd';
import { useAppSelector } from 'app/hooks';
import { menus } from 'constants/menus';
import { ShowRoutes } from 'helper/Func/ShowRoutes';
import { useEffect, useState } from 'react';
import { AiOutlineArrowUp } from 'react-icons/ai';
import { useNavigate } from 'react-router-dom';
import userRoutes from 'routers/userRoutes';
const { Content } = Layout;

const style: React.CSSProperties = {
  height: 40,
  width: 40,
  lineHeight: '40px',
  borderRadius: 4,
  backgroundColor: '#1088e9',
  color: '#fff',
  textAlign: 'center',
  fontSize: 20,
  position: 'absolute',
  bottom: 10,
  left: 80,
  display: 'flex',
  alignItems: 'center',
  justifyContent: 'center',
};
export const Contents: React.FC = () => {
  const isLogin = useAppSelector((state) => state.auth.isLoggedIn);

  let navigate = useNavigate();
  const [title, setTitle] = useState<MODEL.MenuElement>({
    key: '',
    path: '',
    label: '',
    icon: '',
    permission: [],
  });
  useEffect(() => {
    let pathName = window.location.pathname;
    pathName = pathName.replace('/', '');
    const found = menus.find((menu) => menu.path === pathName);

    if (found) {
      if (isLogin) {
        setTitle(found);
      } else if (found.permission.includes('unknown')) {
        setTitle(found);
      }
    } else {
      setTitle({ key: '', path: '', label: '', icon: '', permission: [] });
    }
  }, [isLogin, navigate]);
  return (
    <Content
      style={{
        margin: '0 12px 12px',
        padding: '70px 10px 0',
        minHeight: 280,
      }}
    >
      <Breadcrumb style={{ margin: '16px 0' }}>
        <Breadcrumb.Item >
          {title?.icon} <span>{title?.label}</span>
        </Breadcrumb.Item>
      </Breadcrumb>
      <div
        className="site-layout-background"
        style={{
          minHeight: 360,
        }}
      >
        {ShowRoutes(userRoutes)}
      </div>
      <BackTop visibilityHeight={150}>
        <div style={style}>
          <AiOutlineArrowUp />
        </div>
      </BackTop>
    </Content>
  );
};
