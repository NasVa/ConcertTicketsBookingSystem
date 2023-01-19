import React, { useEffect, useState} from 'react';
import Button from 'react-bootstrap/Button';
import TypesFiltr from './typesFiltr'
import Card from 'react-bootstrap/Card';
import { ConcertsPagination } from './Pagination/ConcertsPagination';
import 'react-paginate'

export  function Home(searchValue){
  const [concerts, setConcerts] = useState([]);
  const [loading, setLoading] = useState(true);
  const [type, setType] = useState('All');
  const [page, setPage] = useState(1);
  const search = searchValue ? `search=${new String(searchValue.searchValue).toLowerCase()}` : '';

  useEffect(() => {
  fetch(`/api/home?type=${type}&${search}&page=${page}`)
    .then( (responce) => responce.json())
    .then( (arr) => {
      setConcerts(arr);
      setLoading(false);
    })
    //console.log(concerts)
  },[type, searchValue, page])

// const filteredConcerts = concerts.filter( concert =>{
//   if (concert.name.toLowerCase().includes(new String(searchValue.searchValue).toLowerCase())){
//     return true
//   }
//   return false
// }) 

  const renderConcerts = () => {
    return (
      <div>
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
      <ConcertsPagination onPageChange={number => setPage(number)}/>
    </div>
  )  
}
