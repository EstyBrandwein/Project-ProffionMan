import Card from 'react-bootstrap/Card';
import { useEffect, useState } from "react";
import { ListGroup } from 'react-bootstrap';

function AddressToClient() {
  const [professionalsMan, setprofessionalsMan] = useState([]);
  useEffect(() => {
    fetch('http://localhost:5251/api/professionalsMan')
      .then(response => response.json())
      .then((data) => {
        //console.log(AddressToClient);
        setprofessionalsMan(data);
        console.log(data);

      })
      .catch(error => console.error(error));

  }, []);

  useEffect(() => {
    console.log("professionalsMan", professionalsMan);
  });

  return (
    <>
      {professionalsMan !== null &&
        <h1 
         style={{ display:'flex'}}
        >
          {professionalsMan.map(x =>
            <Card border="primary" style={{ width: '18rem',fontSize:'1.5rem'}}>
              {/* <Card.Img variant="top" src="holder.js/100px180?text=Image cap" /> */}
              <Card.Body>
                <Card.Title>{x.firstName} {x.lastName}</Card.Title>
                <Card.Text>{x.profession.type}
                </Card.Text>
              </Card.Body>
              <ListGroup className="list-group-flush" >
                <ListGroup.Item >address: {x.address.nighbord}{x.address.city}</ListGroup.Item>
                <ListGroup.Item>phone number: {x.phon}</ListGroup.Item>
                <ListGroup.Item>email: {x.email}</ListGroup.Item>
                <ListGroup.Item>whatsapp: {x.whatsApp}</ListGroup.Item>
                <ListGroup.Item>hourly price: {x.hourlyPrice}</ListGroup.Item>
              </ListGroup>
              
            </Card>
            
          )}
        </h1>
      }
    </>
  )
}
export default AddressToClient;