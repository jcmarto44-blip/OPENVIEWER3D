export default function handler(req, res) {
  const { project, view } = req.query;

  if (!project || !view) {
    return res.status(400).json({
      status: "error",
      message: "Missing project or view"
    });
  }

  // Este es el “comando” que tu plugin leerá después
  const command = {
    action: "openView",
    project: project,
    view: view
  };

  return res.status(200).json({
    status: "ok",
    command: command
  });
}
