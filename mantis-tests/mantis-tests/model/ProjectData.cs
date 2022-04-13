using System;

namespace mantis_tests
{
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public ProjectViewState State { get; set; }
        public string Description { get; set; }

        public enum ProjectStatus : int
        {
            InProgress = 10,
            Released = 30,
            Stable = 50,
            Deprecated = 70
        }

        public enum ProjectViewState : int
        {
            Public = 10,
            Private = 50
        }

        public bool Equals(ProjectData other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name
                && Description == other.Description;
        }

        public int CompareTo(ProjectData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Name.CompareTo(other.Name) != 0)
            {
                return Name.CompareTo(other.Name);
            }
            else
            {
                return Description.CompareTo(other.Description);
            }
        }
    }
}
