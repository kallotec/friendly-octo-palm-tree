import { jobApplicationEntry } from "@/data/types";
import { Container, Divider, ListItemButton, ListItemText, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { getMyApplications } from '@/data/api';

export default async function Home() {

  const rows:jobApplicationEntry[] = await getMyApplications();

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
