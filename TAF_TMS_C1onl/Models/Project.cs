using System.Text.Json.Serialization;
using Newtonsoft.Json;
using TAF_TMS_C1onl.Models.Enums;

namespace TAF_TMS_C1onl.Models
{
    public class Project
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
        [JsonPropertyName("announcement")] public string Announcement { get; set; } = string.Empty;

        [JsonPropertyName("show_announcement")]
        public bool ShowAnnouncement { get; set; }

        [JsonPropertyName("is_completed")] public bool IsCompleted { get; set; }
        [JsonPropertyName("completed_on")] public string CompletedOn { get; set; }
        [JsonPropertyName("suite_mode")] public int SuiteMode { get; set; }
        [JsonPropertyName("default_role_id")] public string DefaultRoleId { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("users")] public List<User> Users { get; set; }
        [JsonPropertyName("groups")] public List<Group> Groups { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}, {nameof(Announcement)}: {Announcement}, {nameof(ShowAnnouncement)}: " +
                $"{ShowAnnouncement}, {nameof(IsCompleted)}: {IsCompleted}, {nameof(CompletedOn)}: {CompletedOn}, {nameof(SuiteMode)}: " +
                $"{SuiteMode}, {nameof(DefaultRoleId)}: {DefaultRoleId}, {nameof(Url)}: {Url}, {nameof(Users)}: {Users}, {nameof(Groups)}: " +
                $"{Groups}";
        }

        protected bool Equals(Project other)
        {
            return Name == other.Name && Announcement == other.Announcement &&
                   ShowAnnouncement == other.ShowAnnouncement && IsCompleted == other.IsCompleted &&
                   CompletedOn == other.CompletedOn && SuiteMode == other.SuiteMode &&
                   DefaultRoleId == other.DefaultRoleId && Url == other.Url;
        }

        public override bool Equals(object? obj)
        {
            return Equals((Project)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(Announcement);
            hashCode.Add(ShowAnnouncement);
            hashCode.Add(IsCompleted);
            hashCode.Add(CompletedOn);
            hashCode.Add(SuiteMode);
            hashCode.Add(DefaultRoleId);
            hashCode.Add(Url);
            hashCode.Add(Users);
            hashCode.Add(Groups);
            return hashCode.ToHashCode();
        }
    }
}