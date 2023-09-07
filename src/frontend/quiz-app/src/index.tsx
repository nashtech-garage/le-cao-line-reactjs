import React from 'react';
import { createRoot } from 'react-dom/client';
import { Provider } from 'react-redux';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { PersistGate } from 'redux-persist/integration/react';
import App from './App';
import index from './app/store';
import './sass/index.scss';
const container = document.getElementById('root')!;
const root = createRoot(container);

root.render(
  <Provider store={index.store}>
    <PersistGate loading={null} persistor={index.persistor}>
      <App />
      <ToastContainer position="top-right" autoClose={2000} />
    </PersistGate>
  </Provider>
);
