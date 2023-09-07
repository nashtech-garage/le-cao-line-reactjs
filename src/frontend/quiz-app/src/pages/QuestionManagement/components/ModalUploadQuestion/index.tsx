import { InboxOutlined } from '@ant-design/icons';
import { Modal, Upload, UploadProps } from 'antd';
import React from 'react';

const { Dragger } = Upload;

const props: UploadProps = {
  name: 'file',
  multiple: true,
  action: 'https://www.mocky.io/v2/5cc8019d300000980a055e76',
};

interface IProps {
  isOpenModal: boolean;
  setOpenModal: any;
}

const ModalUploadQuestion: React.FC<IProps> = ({ isOpenModal, setOpenModal }) => {
  return (
    <Modal
      title="Upload a file"
      visible={isOpenModal}
      onCancel={() => setOpenModal(false)}
      width={500}
      footer={null}
    >
      <div>
        <p>Click here for the question template</p>
        <p>Only excel file with the extension .xlsx and .xls are allowed to be uploaded</p>
        <Dragger {...props}>
          <p className="ant-upload-drag-icon">
            <InboxOutlined />
          </p>
          <p className="ant-upload-text">Click or drag file to this area to upload</p>
        </Dragger>
      </div>
    </Modal>
  );
};

export default ModalUploadQuestion;
