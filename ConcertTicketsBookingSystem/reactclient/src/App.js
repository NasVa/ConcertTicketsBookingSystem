import React, { Component } from 'react';
import { Route, Routes } from 'react-router-dom';
import { CreateConcert } from './components/CreateConcert';
import { Home } from './components/Home';
import { Layout } from './components/Layout';

import './App.css';

function App() {
  return (
    <Layout>
            <Routes>
            <Route exact path='/' element={<Home/>} />
            <Route path='/create-concert' element={<CreateConcert/>}/>
        </Routes>
      </Layout>
  );
}

export default App;
