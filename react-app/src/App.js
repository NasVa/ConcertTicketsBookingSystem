import React from 'react';
import './App.css';
import NaviBar from './components/NaviBar';
import 'bootstrap/dist/css/bootstrap.min.css';

import Home  from "./pages/Home"
import  CreateConcert  from "./pages/CreateConcert"
import {  BrowserRouter as Router,
  Routes, 
  Route,
} from 'react-router-dom';

function App() {
  return (

    <div className="App">
      <Router>
       < NaviBar/ >
       <Routes>
        <Route path="/" element={<Home/>} />
        <Route path="/create-concert" element={<CreateConcert/>} />
       </Routes>
       </Router>
    </div>
  );
}

export default App;

