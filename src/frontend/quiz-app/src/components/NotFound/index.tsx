import { Button, Result } from 'antd';
import { useNavigate } from 'react-router-dom';
const NotFound = () => {
  const navigate = useNavigate();
  
  const handleClick = () => {
    navigate('/home');
  };
  return (
    <Result
      status="404"
      title="404"
      subTitle="Sorry, the page you visited does not exist."
      extra={
        <Button onClick={handleClick} type="primary">
          Back Home
        </Button>
      }
    />
  );
};

export default NotFound;
