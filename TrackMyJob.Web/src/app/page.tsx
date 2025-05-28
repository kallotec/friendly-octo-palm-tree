import { ApplicationList } from "@/ui/ApplicationList";
import { Container, Typography, Divider } from "@mui/material";

export default async function Home() {
  return (
    <Container maxWidth="md">
      <Typography variant="h4" component="h1">Job Applications</Typography>
      <Divider />
      <ApplicationList />
    </Container>
  );
}
