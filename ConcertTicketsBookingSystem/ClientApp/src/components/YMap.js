import React, { useRef} from "react";
import { YMaps, Map, Placemark, ZoomControl, SearchControl, GeolocationControl, FullscreenControl } from 'react-yandex-maps'

export default function YMap(props) {
    const searchControlRef = useRef(null);
   
  const onResShow = () =>{
    if (searchControlRef.current){
      props.setAddress(searchControlRef.current.getResultsArray()[searchControlRef.current.getSelectedIndex()].geometry.getCoordinates()) 
    }
  }

  return (
    <YMaps query={{ apikey: "my_key" }}>
      <div className="YMap">
          <Map defaultState={{ center: [53.902735, 27.555696], zoom: 5 }}>
              <ZoomControl options={{ float: "right" }} />
              <SearchControl
                instanceRef={searchControlRef}
                onResultShow={onResShow}
              />
              <GeolocationControl options={{ float: "left" }} />
              <FullscreenControl />
          </Map>
      </div>
    </YMaps>
    );
}
