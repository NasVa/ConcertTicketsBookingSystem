import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { render } from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const root = document.getElementById('root');

render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  root
  );

