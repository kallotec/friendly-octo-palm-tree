import { Container, Divider, ListItemButton, ListItemText, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import NextLink from 'next/link';

export default function Home() {

  type jobApplicationEntry = {
    id:string,
    companyName:string,
    positionTitle:string,
    appliedAt:string
  };

  const rows:jobApplicationEntry[] = [
    { id: '1', companyName: 'Microsoft', positionTitle: 'Manager', appliedAt: '2025-03-11' },
    { id: '2', companyName: 'Atlassian', positionTitle: 'Manager', appliedAt: '2025-03-13' },
    { id: '3', companyName: 'Trade Me', positionTitle: 'Manager', appliedAt: '2025-03-14' },
    { id: '4', companyName: 'Statistics NZ', positionTitle: 'Manager', appliedAt: '2025-03-15' },
  ].sort((a, b) => b.appliedAt.localeCompare(a.appliedAt));

  return (
    <Container maxWidth="md">
      <Typography variant="h4" component="h1">Job Applications</Typography>
      <Divider />
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell align="left">Company</TableCell>
              <TableCell align="right">Position</TableCell>
              <TableCell align="right">Applied</TableCell>
              <TableCell align="right">Actions</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {rows.map((row) => (
              <TableRow
                key={row.id}
              >
                <TableCell component="th" scope="row">
                  {row.companyName}
                </TableCell>
                <TableCell align="right">{row.positionTitle}</TableCell>
                <TableCell align="right">{row.appliedAt}</TableCell>
                <TableCell align="right">(actions)</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      {/* <ListItemButton component="a" href="#simple-list">
        <ListItemText>Blah</ListItemText>
      </ListItemButton> */}
    </Container>
  );
}
