import React from 'react';
import ReactDOM from 'react-dom';
import './styles/index.scss';
import './styles/fonts.scss';
import './styles/adaptive.scss';
import reportWebVitals from './reportWebVitals';
import { Main } from './pages/main';

ReactDOM.render(
  <React.StrictMode>
    <Main />
  </React.StrictMode>,
  document.getElementById('root')
);

reportWebVitals();
