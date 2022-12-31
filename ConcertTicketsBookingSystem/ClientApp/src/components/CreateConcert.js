import React, { Component} from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Dropdown, DropdownButton } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import YMap from './YMap'

export default class CreateConcert extends Component {
  static displayName = CreateConcert.name;
 

  types = {
    t:["Classic", "Party", "OpenAir"]
  }

  constructor(props) {
    super(props);
    this.state = {
      name : '',
      performer : '',
      ticketsNum : '',
      date : '',
      time : '',
      address : ''
    }
    this.handleSubmit = this.handleSubmit.bind(this)
    this.onInputChange = this.onInputChange.bind(this)
    this.updateAddress = this.updateAddress.bind(this)
  }

  onInputChange(event){
    this.setState({
      [event.target.name] : event.target.value
    })
  }
  
  handleSubmit(event){
    this.sendConcertData();
  }

  updateAddress(_address){
    
    
    this.setState({
      address : _address
    })
    
  }
  
  render() {    
    return (
      <Form onSubmit={this.handleSubmit}>
        <Form.Group className="mb-3" controlId="formConcertName">
          <Form.Label>Concert name</Form.Label>
          <Form.Control type="concert-name" placeholder="Concert name" value = {this.state.name} name = "name" onChange={this.onInputChange}/>
          {/* <Form.Text className="text-muted">
                    We'll never share your email with anyone else.
                </Form.Text> */}
        </Form.Group>
        <Form.Group className="mb-3" controlId="formTicketsNum">
          <Form.Label>Tickets number</Form.Label>
          <Form.Control type="concert-tickets-num" placeholder='Tickets number' name= "ticketsNum" value = {this.state.ticketsNum} onChange={this.onInputChange}/>
        </Form.Group>
        <Form.Control type="number" placeholder="Tickets num" />
        <Form.Group className="mb-3" controlId="dateTime">
          <Form.Label>Date and time</Form.Label>
          <Form.Control type="date" placeholder="Date" name = "date" onChange={this.onInputChange}/>
          <Form.Control type="time" placeholder="Time" name = "time" onChange={this.onInputChange}/>
        </Form.Group>
        <Form.Group className="mb-3" controlId="formPerformer">
          <Form.Label>Rerformer</Form.Label>
          <Form.Control type="performer" placeholder="Performer" name = "performer" value = {this.state.performer} onChange={this.onInputChange}/>
        </Form.Group>
        <Form.Group className="mb-3" controlId="formBasicCheckbox">
          <Form.Check type="checkbox" label="Check me out" />
        </Form.Group>
        <Button variant="primary" type="submit">
          Create
        </Button>

         <DropdownButton variant="dark" id="dropdown" title="Concert type">
          {this.types.t.map(data=>(
            <Dropdown.Item title={data}>{data}</Dropdown.Item>
          ))}
         </DropdownButton>
        {/* <Select options={types}>
          {types.values().map(data=>(
            <option title={data}>{data}</option>
          ))}
          
        </Select> */}
        
        
            {/* <Map
              state={{ center: [53.902735, 27.555696], zoom: 5 }}>
              <Placemark geometry={[53.902735, 27.555696]} name = "address" onChange={this.onInputChange}/>
              <ZoomControl options={{ float: "right" }} />
              <SearchControl options={{ float: "right" }} 
              />
              <GeolocationControl options={{ float: "left" }} />
              <FullscreenControl />
            </Map> */}
            <YMap setAddress={this.updateAddress} />
          

        
      </Form>
    );
  }

 
  async sendConcertData(){
    
    const formData = new FormData();
    formData.append("name", this.state.name);
    formData.append("performer", this.state.performer);
    formData.append("ticketsNum", this.state.ticketsNum);
    formData.append("date", this.state.date);
    formData.append("time", this.state.time);
    formData.append("address", this.state.address);
    debugger;
    const response = await fetch("api/admin/concert/create",
    {
      method: 'POST',
      body: formData
    })
    debugger;
    const data = await response.json() 
  }
}
