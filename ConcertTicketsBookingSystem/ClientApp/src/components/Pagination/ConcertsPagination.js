import React from 'react'
import ReactPaginate from 'react-paginate'
import styles from './Pagination.module.scss'

export function ConcertsPagination({onPageChange}){
  // const [number, setNumber] = useState(1)

  // const items = [];
  // for (let number = 1; number <= 5; number++) {
  //   items.push(
  //     <Pagination.Item key={number} active={number === active}>
  //       {number}
  //     </Pagination.Item>,
  //   );
  // }

  return (
    <div>
    <ReactPaginate
    className={styles.root}
        breakLabel="..."
        nextLabel=">"
        onPageChange={(event) => onPageChange(event.selected + 1)}
        pageRangeDisplayed={5}
        pageCount={5}
        previousLabel="<"
        renderOnZeroPageCount={null}
      />
  </div>
  );
}