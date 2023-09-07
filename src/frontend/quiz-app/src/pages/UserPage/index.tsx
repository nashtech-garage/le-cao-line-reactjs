import { Layout } from 'antd';
import { useAppSelector } from 'app/hooks';
import AppHeader from 'components/AppHeader';
import { Contents } from 'components/Contents';
import { AppFooter } from 'components/Footer';
import { Sidebar } from 'components/Sidebar';
import { useState } from 'react';
import styled from 'styled-components';
const StyledLayout = styled(Layout)`
  transition-duration: 0.2s;
  transition-property: margin;
`;

const { Header, Footer } = Layout;
const UserPage = () => {
  const [collapsed, setCollapsed] = useState(false);
  const user = useAppSelector((state) => state.auth.user);

  const handleChangeCollapsed = () => {
    setCollapsed(!collapsed);
  };
  return (
    <>
      <Layout
        style={{
          minHeight: '100vh',
        }}
      >
        {user ? <Sidebar collapsed={collapsed} handleCollapsed={handleChangeCollapsed} /> : null}
        <StyledLayout
          className="site-layout layout-exam"
          style={user ? (collapsed ? { marginLeft: 80 } : { marginLeft: 250 }) : {}}
        >
          <Header>
            <AppHeader />
          </Header>
          <Contents />
        </StyledLayout>
      </Layout>
      <Footer>
        <AppFooter />
      </Footer>
    </>
  );
};
export default UserPage;
