import React, { Component } from 'react';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import { Dropdown, DropdownButton } from 'react-bootstrap';
import { YMaps, Map, Placemark, ZoomControl, SearchControl, GeolocationControl, FullscreenControl } from '@pbe/react-yandex-maps'
import 'bootstrap/dist/css/bootstrap.min.css';
import Select from 'react-select'


export class CreateConcert extends Component {
  static displayName = CreateConcert.name;
  
  // types = ([
  //   [1, "Classic"], 
  //   [2, "Party"], 
  //   [3, "OpenAir"]
  // ])

  types = {
    t:["Classic", "Party", "OpenAir"]
  }

  constructor(props) {
    super(props);
    
  }


  render() {
    return (
      <Form>
        <Form.Group className="mb-3" controlId="formConcertName">
          <Form.Label>Concert name</Form.Label>
          <Form.Control type="concert-name" placeholder="Concert name" />
          {/* <Form.Text className="text-muted">
                    We'll never share your email with anyone else.
                </Form.Text> */}
        </Form.Group>

        <Form.Control type="number" placeholder="Tickets num" />
        <Form.Group className="mb-3" controlId="dateTime">
          <Form.Label>Date and time</Form.Label>
          <Form.Control type="date" placeholder="Date" />
          <Form.Control type="time" placeholder="Time" />
        </Form.Group>
        <Form.Group className="mb-3" controlId="formPerformer">
          <Form.Label>Rerformer</Form.Label>
          <Form.Control type="performer" placeholder="Performer" />
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

        <YMaps>
          <div>
            <Map
              defaultState={{
                center: [53.902735, 27.555696],
                zoom: 5
              }}>
              <Placemark geometry={[53.902735, 27.555696]} />
              <ZoomControl options={{ float: "right" }} />
              <SearchControl options={{ float: "right" }} />
              <GeolocationControl options={{ float: "left" }} />
              <FullscreenControl />
            </Map>
          </div>
        </YMaps>

      </Form>
    );
  }
}
