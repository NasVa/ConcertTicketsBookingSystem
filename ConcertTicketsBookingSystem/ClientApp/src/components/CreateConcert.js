import React, { Component} from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Dropdown, DropdownButton } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import YMap from './YMap'

export default class CreateConcert extends Component {
  static displayName = CreateConcert.name;
 

  concertTypes = {
    types:["Classic", "Party", "OpenAir"]
  }

  voiceTypes = {
    types:['soprano', 'mezzo-soprano', 'contralto', 'countertenor', 'tenor', 'baritone', 'bass']
  }

  constructor(props) {
    super(props);
    this.state = {
      name : '',
      performer : '',
      ticketsNum : '',
      date : '',
      time : '',
      address : '',
      concertType : 'Classic',
      compositor : '',
      voiceType : '',
      ageLimit : 18,
      path : '',
      headliner : ''
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

  onClickHandlerConcertType = event => {
    
    this.setState({
      concertType : event.target.innerHTML
    })
  }

  onClickHandler = event => {
    
    this.setState({
      voiceType : event.target.innerHTML
    })
  }

  render() {    
    const isClassicType = this.state.concertType == 'Classic'
    const isPartyType = this.state.concertType == 'Party'
    let typeForms;
    if (isClassicType){
      typeForms = 
      <Form>
        <Form.Group className="mb-3" controlId="compositorName">
          <Form.Label>Compositor</Form.Label>
          <Form.Control type="compositor-name" placeholder="Compositor name" value = {this.state.compositor} name = "compositor" onChange={this.onInputChange}/>
        </Form.Group>
        <DropdownButton name = "voiceType" variant="dark" id="voiceTypesDropdown" title="Voice type">
          {this.voiceTypes.types.map(data=>(
            <Dropdown.Item active={this.state.value === data} value={data} onClick={this.onClickHandler} >{data}</Dropdown.Item>
          ))}
         </DropdownButton>
      </Form>
    }
    else if (isPartyType){
      typeForms =
      <Form>
        <Form.Group className="mb-3" controlId="ageLimit">
          <Form.Label>Age limit</Form.Label>
          <Form.Control type="age-limit" placeholder='Age limit' name= "ageLimit" value = {this.state.ageLimit} onChange={this.onInputChange}/>
        </Form.Group>
      </Form>
    }
    else{
      typeForms = 
      <Form>
        <Form.Group className="mb-3" controlId="path">
          <Form.Label>How to get to</Form.Label>
          <Form.Control type="path" placeholder="Path..." value = {this.state.path} name = "path" onChange={this.onInputChange}/>
        </Form.Group>
        <Form.Group className="mb-3" controlId="headliner">
          <Form.Label>Headliner</Form.Label>
          <Form.Control type="headliner" placeholder="Path..." value = {this.state.headliner} name = "headliner" onChange={this.onInputChange}/>
        </Form.Group>
      </Form>

    }
    
    return (
      <Form onSubmit={this.handleSubmit}>
        <Form.Group className="mb-3" controlId="concertName">
          <Form.Label>Concert name</Form.Label>
          <Form.Control type="concert-name" placeholder="Concert name" value = {this.state.name} name = "name" onChange={this.onInputChange}/>
        </Form.Group>
        <Form.Group className="mb-3" controlId="ticketsNum">
          <Form.Label>Tickets number</Form.Label>
          <Form.Control type="concert-tickets-num" placeholder='Tickets number' name= "ticketsNum" value = {this.state.ticketsNum} onChange={this.onInputChange}/>
        </Form.Group>
        <Form.Group className="mb-3" controlId="dateTime">
          <Form.Label>Date and time</Form.Label>
          <Form.Control type="date" placeholder="Date" name = "date" onChange={this.onInputChange}/>
          <Form.Control type="time" placeholder="Time" name = "time" onChange={this.onInputChange}/>
        </Form.Group>
        <Form.Group className="mb-3" controlId="formPerformer">
          <Form.Label>Rerformer</Form.Label>
          <Form.Control type="performer" placeholder="Performer" name = "performer" value = {this.state.performer} onChange={this.onInputChange}/>
        </Form.Group>
        
         <DropdownButton name = "concertType" variant="dark" id="dropdown" title="Concert type">
          {this.concertTypes.types.map(data=>(
            <Dropdown.Item  value={data} onClick={this.onClickHandlerConcertType} >{data}</Dropdown.Item>
          ))}
         </DropdownButton>
         {typeForms}
        <YMap setAddress={this.updateAddress} />
        <Button variant="primary" type="submit">
          Create
        </Button>
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
    formData.append("concertType", this.state.concertType);
    formData.append("compositor", this.state.compositor);
    formData.append("ageLimit", this.state.ageLimit);
    formData.append("path", this.state.path);
    formData.append("headliner", this.state.headliner);
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
