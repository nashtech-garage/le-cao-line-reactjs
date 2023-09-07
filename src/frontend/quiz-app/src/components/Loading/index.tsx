import { Spin } from 'antd';
function Loading() {
  return (
    // <div className="loader-container">
    //   <div className="loader-container-inner">
    //   </div>
    // </div>
    <div className="modal--ant">
      <div className="modal__overlay--ant"></div>
      <div className="loading__body">
        <Spin />
      </div>
    </div>
  );
}

export default Loading;
