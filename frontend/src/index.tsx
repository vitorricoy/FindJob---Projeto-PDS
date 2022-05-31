import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { createGlobalState } from 'react-hooks-global-state';
import User from './models/User';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

const { setGlobalState, useGlobalState } = createGlobalState({
  currentUser: JSON.parse(localStorage.getItem("currentUser") || "{}") as User
});

export { setGlobalState, useGlobalState };

root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
