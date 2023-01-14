import React, { useEffect, useState} from 'react';
import Button from 'react-bootstrap/Button';
import TypesFiltr from './typesFiltr'
import Card from 'react-bootstrap/Card';

export  function Home(){
  const [concerts, setConcerts] = useState(['fdfd']);
  const [loading, setLoading] = useState(true);
  const [type, setType] = useState('All');


  useEffect(() => {
    console.log(type)
  fetch("/api/home?type=" + type)
    .then( (responce) => responce.json())
    .then( (arr) => {
      setConcerts(arr);
      setLoading(false);
    })
    console.log(concerts)
  },[type])

 

  const renderConcerts = () => {
    return (
      <div>
        {/* <TypesFiltr />  */}
        {concerts.map(concert => (
          <Card>
            <Card.Header as="h5">{concert.name}</Card.Header>
            <Card.Body>
              <Card.Title>{concert.performer}</Card.Title>
              <Card.Text>
                DateTime: {concert.dataTime}
                Address: {concert.address}
              </Card.Text>
              <Button variant="primary">More information</Button>
            </Card.Body>
        </Card>
        ))}
      </div>
    );
    
  }

  const updateType = (_type) => {
    setType(_type);
    setLoading(true)
  }

  //  const getConcerts = () =>{
  //   fetch("/api/home?type=" + type)
  //   .then( (responce) => responce.json())
  //   .then( (arr) => {
  //     setConcerts(arr);
  //     setLoading(false);
  //   },[type])
  //   console.log(concerts)
  //  }

  let content = loading ? <p>loading...</p> : renderConcerts(concerts);
  return(
    <div>
      <TypesFiltr setType = {updateType} /> 
      {content}
    </div>
  )  
}


// import React, { Component } from 'react';
// import Button from 'react-bootstrap/Button';
// import TypesFiltr from './typesFiltr'
// import Card from 'react-bootstrap/Card';
// import { data } from 'jquery';

// export  class Home extends Component {
//   static displayName = Home.name;

//   constructor(props){
//     super(props);
//     this.state = { concerts: [], loading: true, type : 'All'}
//     this.updateType = this.updateType.bind(this)
//   }

//   componentDidMount(){
//     this.getConcerts();
//   }

//   static renderConcerts(concerts){
//     return (

//       <div>
//         {/* <TypesFiltr />  */}
//         {concerts.map(concert => (
//           <Card>
//             <Card.Header as="h5">{concert.name}</Card.Header>
//             <Card.Body>
//               <Card.Title>{concert.performer}</Card.Title>
//               <Card.Text>
//                 DateTime: {concert.dataTime}
//                 Address: {concert.address}
//               </Card.Text>
//               <Button variant="primary">More information</Button>
//             </Card.Body>
//         </Card>
//         ))}
//       </div>

//     );
    
//   }

//   updateType(_type){
//     this.setState({
//       type: _type, loading: true
//     })
//     this.getConcerts()
//   }

//   render() {
//     let content = this.state.loading ? <p>loading...</p> : Home.renderConcerts(this.state.concerts);
//       return (
//         <div>
//         <TypesFiltr setType = {this.updateType} /> 
//         {content}
//         </div>
//     );
//   }

//   async getConcerts(){
//     const responce = await fetch("/api/home/" + this.state.type);
//     const data = await responce.json()
//     this.setState({concerts: data, loading: false});
//   }
// }
