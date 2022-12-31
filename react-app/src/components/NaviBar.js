import { Container, Nav, Navbar, Button} from 'react-bootstrap';
import { Link } from 'react-router-dom';

function NaviBar() {
  return (
    <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand>Concert Booking System</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link><Link to = "/">Home</Link></Nav.Link>
            <Nav.Link><Link to = "/create-concert">New concert</Link></Nav.Link>
          </Nav>
          <Nav className="me-2">
            <Button vatiant="primary"> Log In</Button>
            <Button vatiant="primary"> Sign Out</Button>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default NaviBar;