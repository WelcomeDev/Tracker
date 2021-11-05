import React from 'react';
import ReactDOM from 'react-dom';
import './styles/index.scss';
import './styles/fonts.scss';
import App from './app/app';
import reportWebVitals from './reportWebVitals';

ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

reportWebVitals();
