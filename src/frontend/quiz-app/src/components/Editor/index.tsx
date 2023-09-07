import ReactQuill from 'react-quill';

interface IEditorProps {
  handleEditorChange: any;
  value?: any;
  modules?: any;
  formats?: any;
  isReadOnly?: boolean;
  theme?: string;
  isBorderClass?: boolean;
}

const Editor: React.FC<IEditorProps> = ({
  handleEditorChange,
  value,
  modules,
  formats,
  isReadOnly,
  theme,
  isBorderClass,
}) => {
  console.log(modules);

  const module = !modules
    ? {
        toolbar: [
          [{ header: [1, 2, false] }],
          ['bold', 'italic', 'underline', 'strike', 'blockquote'],
          [{ list: 'ordered' }, { list: 'bullet' }, { indent: '-1' }, { indent: '+1' }],
          ['link', 'image'],
          ['clean'],
        ],
      }
    : modules;

  const format = !formats
    ? [
        'header',
        'bold',
        'italic',
        'underline',
        'strike',
        'blockquote',
        'list',
        'bullet',
        'indent',
        'link',
        'image',
      ]
    : formats;

  return (
    <div>
      <ReactQuill
        className={isBorderClass ? 'ql-item' : ''}
        readOnly={isReadOnly}
        formats={format}
        modules={module}
        value={value}
        onChange={handleEditorChange}
        theme={theme}
      />
    </div>
  );
};

export default Editor;
