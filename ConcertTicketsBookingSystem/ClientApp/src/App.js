import React from 'react';
import { Route, Routes } from 'react-router-dom';
import  CreateConcert  from './components/CreateConcert';
import { Home } from './components/Home';
import { Layout } from './components/Layout';
import { NavMenu } from './components/NavMenu';
import './custom.css';

export default function App(){
  const [searchValue, setSearchValue] = React.useState('');

  
    return (
        <Layout>
          <NavMenu searchValue={searchValue} setSearchValue={setSearchValue} />
            <Routes>
            <Route exact path='/' element={<Home searchValue={searchValue}/>} />
            <Route path='/create-concert' element={<CreateConcert/>}/>
          </Routes>
        </Layout>
    );
  
}
