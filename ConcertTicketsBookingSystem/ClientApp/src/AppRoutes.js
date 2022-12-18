import { Counter } from "./components/Counter";
import { CreateConcert } from "./components/CreateConcert";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
    },
  {
    path: '/create-concert',
    element: <CreateConcert />
  }
];

export default AppRoutes;
